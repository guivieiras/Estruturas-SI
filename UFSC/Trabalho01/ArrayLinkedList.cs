using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho01 {

    class ArrayLinkedList<T> {

        T[] array;
        int[] links;

        int firstIndex = -1;
        int lastIndex = -1;
        int firstEmptySpace = 0;

        public static void Test() {
            ArrayLinkedList<string> sall = new ArrayLinkedList<string>(4);


            List<string> das = new List<string>();

            sall.Add("a");
            sall.Add("b");
            sall.Add("c");
            sall.InsertAfter("a", "d");

            das.Add("a");
            das.Add("b");
            das.Add("c");
            das.Insert(1, "d");

            Console.WriteLine(string.Join(", ", das));
            Console.WriteLine(string.Join(", ", sall.ToEnumerable()));
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator() {
            return ToEnumerable().GetEnumerator();
        }

        public IEnumerable<T> ToEnumerable() {
            int iterator = firstIndex;
            while (iterator != -1) {
                yield return array[iterator];
                iterator = links[iterator];
            }
        }

        public bool IsEmpty { get { return firstIndex == -1; } }

        public bool IsFull { get { return firstEmptySpace == -1; } }

        private bool LastElement { get { return firstIndex == lastIndex; } }

        public int Size { get { return array.Length; } }

        public ArrayLinkedList(int size) {
            array = new T[size];
            links = new int[size];
            CreateLinkArray();
        }

        // Inicializa o array de links para determinar o começo e o fim dos espaços em branco, começando em 1 e terminando em -1.
        private void CreateLinkArray() {
            int i = 0;
            for (; i < Size - 1; i++) {
                links[i] = i + 1;
            }
            links[i] = -1;
        }


        public void InsertAtFirst(T value) {
            if (IsFull)
                throw new Exception("List is full");

            if (IsEmpty) {
                Add(value);
                return;
            }

            //Bota o valor no primeiro espaço em branco
            array[firstEmptySpace] = value;

            //Muda o primeiro espaço em branco para o seguinte.
            int position = firstEmptySpace;
            firstEmptySpace = links[firstEmptySpace];

            //Bota o indice do próximo valor o indice do ex-primeiro elemento.
            links[position] = firstIndex;

            //Muda o indice do primeiro item
            firstIndex = position;
            return;

        }

        public void Add(T value) {
            if (IsFull)
                throw new Exception("List is full");

            int position = firstEmptySpace;

            //Bota o valor no primeiro espaço em branco
            array[position] = value;

            //Muda o primeiro espaço em branco para o seguinte.
            firstEmptySpace = links[firstEmptySpace];

            //Bota o indice do próximo valor como -1, já que este é o ultimo da lista.
            links[position] = -1;

            if (IsEmpty) {
                firstIndex = position;
            } else {
                //Bota o indice do item como próximo do ultimo.
                links[lastIndex] = position;
            }
            lastIndex = position;

        }

        public void InsertAt(int index, T value) {
            if (IsFull)
                throw new Exception("List is full");
            if (index != 0 && IsEmpty) {
                throw new IndexOutOfRangeException("When empty, only accepts index 0.");
            }
            if (index < 0) {
                throw new IndexOutOfRangeException("Negative index.");
            }
            if (index == 0) {
                InsertAtFirst(value);
                return;
            }

            //Iterador para encontrar o indice do elemento na posição 'index'
            int prevPosition = firstIndex;
            while (index > 1) {
                prevPosition = links[prevPosition];
                if (prevPosition == -1 && index > 1) {
                    throw new IndexOutOfRangeException("Index out of bounds.");
                }
                index--;
            }
            Insert(prevPosition, value);
        }

        //Método auxiliar para inserir de acordo com o indice interno dos elementos.
        private void Insert(int index, T value) {
            if (IsFull)
                throw new Exception("List is full");

            //Caso indice cair na ultima posição, usar método add.
            int position = firstEmptySpace;
            //Bota o valor no primeiro espaço em branco
            array[position] = value;

            //Muda o primeiro espaço em branco para o seguinte.
            firstEmptySpace = links[firstEmptySpace];

            //Bota o indice do próximo valor o próximo do anterior.
            links[position] = links[index];

            //Bota o indice do item como próximo do anterior.
            links[index] = position;

            if (links[position] == -1) {
                lastIndex = position;
            }
        }

        public void InsertAfter(T element, T value) {
            if (IsEmpty)
                throw new Exception("List is empty, no way to find element.");

            int internalIndex = GetInternalIndex(element);

            if (internalIndex == lastIndex)
                Add(value);
            else
                Insert(internalIndex, value);
        }

        public void InserfBefore(T element, T value) {
            if (IsEmpty)
                throw new Exception("List is empty, no way to find element.");

            int internalIndex = GetPreviousInternalIndex(element);

            if (internalIndex == -1)
                InsertAtFirst(value);
            else
                Insert(internalIndex, value);
        }


        public int IndexOf(T element) {
            int index = 0;
            int position = firstIndex;
            while (position != -1 && !array[position].Equals(element)) {
                position = links[position];
                index++;
            }
            if (position != -1 && array[position].Equals(element))
                return index;
            else
                throw new Exception("Element not found");
        }

        //Retorna o index interno de determinado elemento.
        private int GetInternalIndex(T element) {
            int position = firstIndex;
            while (position != -1 && !array[position].Equals(element)) {
                position = links[position];
            }

            if (position != -1 && array[position].Equals(element))
                return position;
            else
                throw new Exception("Element not found");
        }

        //Retorna o index interno do elemento anterior. -1 se o elemento for o primeiro da lista.
        private int GetPreviousInternalIndex(T element) {

            if (array[firstIndex].Equals(element))
                return -1;

            int position = firstIndex;
            while (position != -1 && links[position] != -1 && !array[links[position]].Equals(element)) {
                position = links[position];
            }

            if (position != -1 && links[position] != -1 && array[links[position]].Equals(element))
                return position;
            else
                throw new Exception("Element not found");
        }

        public void RemoveAt(int index) {
            if (index == 0) {
                RemoveFirst();
                return;
            }

            int prevPosition = firstIndex;

            while (index > 1) {
                prevPosition = links[prevPosition];
                if (prevPosition == -1) {
                    throw new IndexOutOfRangeException(index + ": Index out of bounds");
                }
                index--;
            }
            RemoveNext(prevPosition);
        }

        //Método auxiliar para remover o item sucessor do indice passado como argumento. 
        private void RemoveNext(int previousIndex) {
            if (previousIndex == -1) {
                RemoveFirst();
                return;
            }
            int position = links[previousIndex];
            int nextPosition = links[position];

            //Bota o proximo item do removido como o proximo do anterior à ser removido.
            links[previousIndex] = nextPosition;
            //Bota o indice do espaço em branco no item que será removido.
            links[position] = firstEmptySpace;
            //Altera o primeiro espaço vazio para o indice do item a ser removido.
            firstEmptySpace = position;

            if (lastIndex == firstEmptySpace)
                lastIndex = previousIndex;
        }

        public void Remove(T value) {
            RemoveNext(GetPreviousInternalIndex(value));
        }

        public void RemoveLast() {
            if (LastElement) {
                RemoveFirst();
                return;
            }

            int previous = firstIndex;

            while (links[previous] != lastIndex) {
                previous = links[previous];
            }

            RemoveNext(previous);
        }

        public void RemoveFirst() {

            if (LastElement) {
                links[firstIndex] = firstEmptySpace;
                firstEmptySpace = firstIndex;

                lastIndex = -1;
                firstIndex = -1;
            } else {
                int toRemove = firstIndex;
                firstIndex = links[firstIndex];

                links[toRemove] = firstEmptySpace;
                firstEmptySpace = toRemove;
            }
        }

        public bool Contains(T value) {
            try {
                IndexOf(value);
                return true;
            } catch {
                return false;
            }
        }

        //- [X] inserir novo elemento na frente da lista 
        //- [X] inserir novo elemento na n-ésima posição da lista
        //- [X] inserir novo elemento depois do elemento X da lista
        //- [X] inserir novo elemento no final da lista
        //- [X] inserir novo elemento antes do elemento X da lista
        //- [X] excluir n-ésimo elemento
        //- [X] excluir elemento X
        //- [X] excluir último elemento
        //- [X] excluir primeiro elemento
        //- [ ] buscar elemento X

    }
}
