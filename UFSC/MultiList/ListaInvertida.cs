using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//K = chave da classe, T = tipo da classe
public abstract class ListaInvertida<K, T>
{

    //Dicionario com nome do atributo como chave e valor um dicionario, chave dinamica = valor do atributo, valor = id's dos alunos que tem esse valor nesse atributo
    public Dictionary<string, Dictionary<object, List<K>>> directories { get; set; }
    public List<PropertyInfo> properties;
    public List<T> items { get; set; } = new List<T>();


    public ListaInvertida()
    {
        this.properties = GetPropriedades();

        directories = new Dictionary<string, Dictionary<object, List<K>>>();

        properties.ForEach(v =>
        {
            directories.Add(v.Name, new Dictionary<object, List<K>>());
        });
    }

    public abstract K GetKey(T item);

    public void Add(T item)
    {
        items.Add(item);

        properties.ForEach(property =>
        {
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
