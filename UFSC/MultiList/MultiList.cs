using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Aluno
{

    [Key]
    public int Id { get; set; }

    [NotMapped]
    public string Nome { get; set; }

    public Cidade Cidade { get; set; }
    public string Curso { get; set; }
    public string Time { get; set; }

    public Aluno(int codigo, string name, Cidade cidade, string curso, string time)
    {
        this.Id = codigo;
        this.Nome = name;
        this.Cidade = cidade;
        this.Curso = curso;
        this.Time = time;
    }
}
public class Cidade
{
    public string Nome { get; set; }

    public Cidade(string nome)
    {
        Nome = nome;
    }
}


public class LinhaDiretorio
{
    //nome do time exemplo
    public string key { get; set; }
    //Codigos de pessoas com tal time
    public List<int> values { get; set; }

    public void Add(int value)
    {
        if (!values.Contains(value))
            values.Add(value);
    }
    public void Remove(int value)
    {
        if (values.Contains(value))
            values.Remove(value);
    }
    public LinhaDiretorio(string key)
    {
        this.key = key;
    }
}

public class Diretorios
{

    //         Dicionario com nome do atributo como chave e dicionario como valor do atributo como chave com valores no
    public Dictionary<string, Dictionary<string, List<int>>> directories { get; set; }
    public List<PropertyInfo> properties;

    public Diretorios(List<PropertyInfo> properties)
    {
        this.properties = properties;

        directories = new Dictionary<string, Dictionary<string, List<int>>>();

        properties.ForEach(v =>
        {
            directories.Add(v.Name, new Dictionary<string, List<int>>());
        });
    }


    public void Add(Aluno aluno)
    {
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

//K = chave da classe, T = tipo da classe
public abstract class ListaInvertida<K, T>
{

    //Dicionario com nome do atributo como chave e valor um dicionario, chave dinamica = valor do atributo, valor = id's dos alunos que tem esse valor nesse atributo
    public Dictionary<string, Dictionary<dynamic, List<K>>> directories { get; set; }
    public List<PropertyInfo> properties;
    public List<T> items { get; set; } = new List<T>();


    public ListaInvertida()
    {
        this.properties = GetPropriedades();

        directories = new Dictionary<string, Dictionary<dynamic, List<K>>>();

        properties.ForEach(v =>
        {
            directories.Add(v.Name, new Dictionary<dynamic, List<K>>());
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

public class Alunos : ListaInvertida<int, Aluno>
{
    public override int GetKey(Aluno value)
    {
        return value.Id;
    }
}

public class Multilist
{
    public static void Test()
    {
        AlunoMultilist am = new AlunoMultilist();

        //Aluno 
        //a = new Aluno(0, "A", "Big", "SIN", "FIG");
        //am.Add(a);
        //a = new Aluno(1, "A", "São", "CCO", "FIG");
        //am.Add(a);
        //a = new Aluno(2, "A", "Big", "CCO", "CRI");
        //am.Add(a);

        Alunos am2 = new Alunos();
        var big = new Cidade("Big");
        var s = new Cidade("São");
        Aluno
        a = new Aluno(0, "A", big, "SIN", "FIG");
        am2.Add(a);
        a = new Aluno(1, "A", s, "CCO", "FIG");
        am2.Add(a);
        a = new Aluno(2, "A", big, "CCO", "CRI");
        am2.Add(a);
    }
}

public class AlunoMultilist
{



    public List<Aluno> alunos { get; set; }
    public Diretorios diretorios { get; set; }

    //Nome da ciade/curso/time como string e id do aluno como int, obtendo um diretorio de chave string e valores int
    public AlunoMultilist()
    {
        diretorios = new Diretorios(properties(typeof(Aluno)));
    }

    public void Add(Aluno aluno)
    {
        diretorios.Add(aluno);
    }

    public static List<PropertyInfo> properties(Type type)
    {
        return type.GetProperties().Where
            (x => x.CustomAttributes.Where
                (o => o.AttributeType == typeof(KeyAttribute)
                || o.AttributeType == typeof(NotMappedAttribute)).Count() == 0).ToList();
    }

    public static List<string> PropertiesNames(Type type)
    {
        var q = type.GetProperties().Where
            (x => x.CustomAttributes.Where
                (o => o.AttributeType == typeof(KeyAttribute)
                || o.AttributeType == typeof(NotMappedAttribute)).Count() == 0).Select(a => a.Name);

        return q.ToList();
    }
}