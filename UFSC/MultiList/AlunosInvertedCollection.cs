public class AlunosInvertedCollection : ListaInvertida<int, Aluno>
{
    public override int GetKey(Aluno value)
    {
        return value.Id;
    }
}
