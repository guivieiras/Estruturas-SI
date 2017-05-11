using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests {

    class SimpleArrayLinkedList {

        int[] array;
        int[] links;

        int firstIndex = -1;
        int lastIndex = -1;
        int firstEmptySpace = 0;

        public static void Test() {
            SimpleArrayLinkedList sall = new SimpleArrayLinkedList(12);

            sall.Add(1);
            sall.RemoveLast();
            sall.Add(1);

            sall.Add(2);
            sall.Add(3);
            sall.Add(4);
            sall.RemoveAt(1);
            sall.Add(5);
            sall.InsertAt(3, 0);
            sall.InserfBefore(4, 8);
            sall.InsertAt(2, 7);
            sall.RemoveAt(3);
            sall.RemoveAt(3);
            sall.RemoveAt(3);
            sall.InserfBefore(1, 9);
            sall.InserfBefore(9, 0);
            sall.InsertAfter(5, 6);
            sall.RemoveLast();
            sall.RemoveLast();

            sall.RemoveFirst();
            sall.RemoveFirst();
            sall.RemoveAt(1);

            sall.Add(2);
            sall.Add(3);
            sall.Add(4);

          
            sall.Remove(2);
            sall.Remove(3);
            sall.Remove(4);
            sall.Remove(1);
            sall.Remove(7);

            sall.Add(0);
            sall.Add(1);
            sall.Add(2);
            sall.Add(3);
            sall.Add(5);
            sall.Add(4);
            sall.Add(6);
            sall.Add(7);
            sall.Add(8);
            sall.Add(9);
            sall.RemoveAt(0);
            List<int> das = new List<int>();

            das.Add(1);
            das.Add(2);
            das.Add(3);
            das.Add(4);
            das.RemoveAt(1);
            das.Add(5);
            das.Insert(3, 0);
            das.Insert(das.IndexOf(4), 8);
            das.Insert(2, 7);
            das.RemoveAt(3);
            das.RemoveAt(3);
            das.RemoveAt(3);
            das.Insert(das.IndexOf(1), 9);
            das.Insert(das.IndexOf(9), 0);
            das.Insert(das.IndexOf(5) + 1, 6);
            das.RemoveAt(das.Count - 1);
            das.RemoveAt(das.Count - 1);

            das.RemoveAt(0);
            das.RemoveAt(0);
            das.RemoveAt(1);

            das.Add(2);
            das.Add(3);
            das.Add(4);

            das.Remove(2);
            das.Remove(3);
            das.Remove(4);
            das.Remove(1);
            das.Remove(7);

            das.Add(0);
            das.Add(1);
            das.Add(2);
            das.Add(3);
            das.Add(5);
            das.Add(4);
            das.Add(6);
            das.Add(7);
            das.Add(8);
            das.Add(9);
            das.RemoveAt(0);
            das.Remove(5);
            sall.Remove(5);
            sall.InserfBefore(6, 90);
            das.Insert(das.IndexOf(6), 90);
            sall.InsertAfter(4, 89);
            das.Insert(das.IndexOf(4) + 1, 89);
            sall.InsertAfter(9, 80);
            sall.InserfBefore(1, 0);
            das.Insert(0, 0);
            das.Insert(das.Count, 80);
            das.Remove(0);
            sall.RemoveAt(0);

            sall.InsertAt(11, 115);
            das.Insert(11, 115);

            Console.WriteLine(sall.Contains(115));

            Console.WriteLine(string.Join(", ", das));
            Console.WriteLine(string.Join(", ", sall.ToEnumerable()));
            Console.WriteLine();
        }

        public IEnumerator<int> GetEnumerator() {
            return ToEnumerable().GetEnumerator();
        }

        public IEnumerable<int> ToEnumerable() {
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

        public SimpleArrayLinkedList(int size) {
            array = new int[size];
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


        public void InsertAtFirst(int value) {
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

        public void Add(int value) {
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

        public void InsertAt(int index, int value) {
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
        private void Insert(int index, int value) {
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

        public void InsertAfter(int element, int value) {
            if (IsEmpty)
                throw new Exception("List is empty, no way to find element.");

            int internalIndex = GetInternalIndex(element);

            if (internalIndex == lastIndex)
                Add(value);
            else
                Insert(internalIndex, value);
        }

        public void InserfBefore(int element, int value) {
            if (IsEmpty)
                throw new Exception("List is empty, no way to find element.");

            int internalIndex = GetPreviousInternalIndex(element);

            if (internalIndex == -1)
                InsertAtFirst(value);
            else
                Insert(internalIndex, value);
        }


        public int IndexOf(int element) {
            int index = 0;
            int position = firstIndex;
            while (position != -1 && array[position] != element) {
                position = links[position];
                index++;
            }
            if (position != -1 && array[position] == element)
                return index;
            else
                throw new Exception("Element not found");
        }

        //Retorna o index interno de determinado elemento.
        private int GetInternalIndex(int element) {
            int position = firstIndex;
            while (position != -1 && array[position] != element) {
                position = links[position];
            }

            if (position != -1 && array[position] == element)
                return position;
            else
                throw new Exception("Element not found");
        }
        
        //Retorna o index interno do elemento anterior. -1 se o elemento for o primeiro da lista.
        private int GetPreviousInternalIndex(int element) {

            if (array[firstIndex] == element)
                return -1;

            int position = firstIndex;
            while (position != -1 && links[position] != -1 && array[links[position]] != element) {
                position = links[position];
            }

            if (position != -1 && links[position] != -1 && array[links[position]] == element)
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

        public void Remove(int value) {
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

        public bool Contains(int value) {
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
