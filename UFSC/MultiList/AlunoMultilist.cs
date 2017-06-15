using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
public class AlunoMultilist
{
    public List<Aluno> alunos { get; set; }

    //         Dicionario com nome do atributo como chave e dicionario como valor do atributo como chave com valores no

    public Dictionary<string, Dictionary<string, List<int>>> directories { get; set; }
    public List<PropertyInfo> properties;

    public AlunoMultilist()
    {
        this.properties =  GetProperties(typeof(Aluno));

        directories = new Dictionary<string, Dictionary<string, List<int>>>();

        properties.ForEach(v =>
        {
            directories.Add(v.Name, new Dictionary<string, List<int>>());
        });
    }

    public static List<PropertyInfo> GetProperties(Type type)
    {
        return type.GetProperties().Where
            (x => x.CustomAttributes.Where
                (o => o.AttributeType == typeof(KeyAttribute)
                || o.AttributeType == typeof(NotMappedAttribute)).Count() == 0).ToList();
    }



    public void Add(Aluno aluno)
    {
        alunos.Add(aluno);

        properties.ForEach(property =>
        {
            if (!directories[property.Name].ContainsKey(property.GetValue(aluno).ToString()))
            {
                directories[property.Name].Add((string)property.GetValue(aluno), new List<int>());
            }

            directories[property.Name][(string)property.GetValue(aluno)].Add(aluno.Id);
        });
    }
}
