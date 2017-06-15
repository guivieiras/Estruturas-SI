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
    public double Tamanho { get; set; }

    public Aluno(int codigo, string name, Cidade cidade, string curso, string time, double tamanho)
    {
        this.Id = codigo;
        this.Nome = name;
        this.Cidade = cidade;
        this.Curso = curso;
        this.Time = time;
        Tamanho = tamanho;
    }
}
