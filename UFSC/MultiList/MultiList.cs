using UFSC.MultiList;

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

        AlunosInvertedCollection am2 = new AlunosInvertedCollection();
        var big = new Cidade("Big");
        var s = new Cidade("São");

        AlunosInvertedContinuousCollection aldaw = new AlunosInvertedContinuousCollection(2,3);

        Aluno
        a = new Aluno(0, "A", big, "SIN", "FIG", 1);
        am2.Add(a);
        aldaw.Add(a);

        a = new Aluno(1, "A", s, "CCO", "FIG", 2);
        am2.Add(a);
        aldaw.Add(a);

        a = new Aluno(2, "A", big, "CCO", "CRI", 3);
        aldaw.Add(a);
        am2.Add(a);

        a = new Aluno(2, "A", big, "CCO", "CRI", 4);
        aldaw.Add(a);
        am2.Add(a);

        a = new Aluno(2, "A", big, "CCO", "CRI", 5);
        aldaw.Add(a);
        am2.Add(a);


    }
}
