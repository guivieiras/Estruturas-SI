using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
//K = chave da classe, T = tipo da classe
public abstract class ListaContinuaInvertida<K, T>
{

    //Dicionario com nome do atributo como chave e valor um dicionario, chave dinamica = valor do atributo, valor = id's dos alunos que tem esse valor nesse atributo
    public Dictionary<string, Dictionary<object, List<K>>> directories { get; set; }
    public List<PropertyInfo> properties;
    public List<T> items { get; set; } = new List<T>();
    double[] range;
    double[] firstSmaller;

    public ListaContinuaInvertida(double? range = null, double? firstSmaller = null)
    {
        this.range = new double[1];
        this.firstSmaller = new double[1];

        this.range[0] = range.Value;
        this.firstSmaller[0] = firstSmaller.Value;

        this.properties = GetPropriedades();

        directories = new Dictionary<string, Dictionary<object, List<K>>>();
        double x = 0d / 0d;
        properties.ForEach(v =>
        {
            directories.Add(v.Name, new Dictionary<object, List<K>>());
        });
    }



    public abstract K GetKey(T item);

    public void Add(T item)
    {
        items.Add(item);
        int count = 0;
        properties.ForEach(property =>
        {
            if (property.PropertyType == typeof(double))
            {
                double value = (double)property.GetValue(item);
                double index = (value - firstSmaller[count]) / range[count];
                index = Math.Floor(index);
                if (!directories[property.Name].ContainsKey(index))
                {
                    directories[property.Name].Add(index, new List<K>());
                }
            }
            if (!directories[property.Name].ContainsKey(property.GetValue(item)))
            {
                directories[property.Name].Add(property.GetValue(item), new List<K>());
            }

            directories[property.Name][property.GetValue(item)].Add(GetKey(item));
        });
    }

    public List<PropertyInfo> GetPropriedades()
    {
        return typeof(T).GetProperties().Where
            (x => x.CustomAttributes.Where
                (o => o.AttributeType == typeof(KeyAttribute)
                || o.AttributeType == typeof(NotMappedAttribute)).Count() == 0).ToList();
    }
}
