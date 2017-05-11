using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared {
    public class LinkedElement<T> {
        
            private LinkedElement<T> parent;

            public LinkedElement(T valor) {
                this.valor = valor;
            }

            public void setParent(LinkedElement<T> element) {
                this.parent = element;
            }

            public LinkedElement<T> getParent() {
                return parent;
            }

            public T valor;
     
    }

   
    
}
