public class Aluno{

	public int codigo{get;set;}
	public string name{get;set;}
	public string cidade;
	public string curso;
	public string time;

	public Aluno(int codigo, string name, string cidade, string curso, string time){
		this.codigo = codigo;
		this.name = name;
		this.cidade = cidade;
		this.curso = curso;
		this.time = time;
	}
}



public Diretorio{
	//nome do diretorio
	public string key {get;set;}
	public List<int> values {get;set;}

	public void Add(V value)
	{
		if(!values.Contains(value))
			values.Add(value);
	}
	public void Add(V value)
	{
		if(values.Contains(value))
			values.Remove(value);
	}
	public Diretorio(K key){
		this.key = key;
	}
}

public Diretorios{
	
	public List<Diretorio> directories {get;set;}

	public void Add(int value)
	{
		if(!values.Contains(value)){
			foreach(Diretorio dir in directories){
				dir.Add(value);
			}
		}		
	}
}


public class AlunoMultilist{
	
	public List<Aluno> alunos {get;set;}
	public Diretorios diretorios {get;set;}

	//Nome da ciade/curso/time como string e id do aluno como int, obtendo um diretorio de chave string e valores int
	public AlunoMultilist{
		Diretorio dirCidade = new Diretorio("cidade");
		Diretorio dirCurso = new Diretorio("curso");	
		Diretorio dirTime = new Diretorio("time");
	}

	public Add(Aluno aluno){		
		aluno.diretorios.Add(aluno);
		values.Add(value);
	}
		
		











}