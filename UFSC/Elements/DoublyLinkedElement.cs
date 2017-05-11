using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements {
    public class DoublyLinkedElement<T> {

        private DoublyLinkedElement<T> next;
        private DoublyLinkedElement<T> previous;

        public DoublyLinkedElement(T valor) {
            this.Valor = valor;
        }

        private T valor;

        public DoublyLinkedElement<T> Next {
            get {
                return next;
            }

            set {
                next = value;
            }
        }

        public DoublyLinkedElement<T> Previous {
            get {
                return previous;
            }

            set {
                previous = value;
            }
        }

        public T Valor {
            get {
                return valor;
            }

            set {
                valor = value;
            }
        }
    }
}
