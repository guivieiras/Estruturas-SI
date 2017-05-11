using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests {
    public class DictionaryTest {
        public static void test1() {
            Dictionary<int, something> file = new Dictionary<int, something>();
            Dictionary<int, Lel> tagWithEmbeedList = new Dictionary<int, Lel>();

        }

        public static void test2() {
            Dictionary<int, something> file = new Dictionary<int, something>();
            Dictionary<int, xis> tag = new Dictionary<int, xis>();
            Dictionary<int, List<something>> withHashedList = new Dictionary<int, List<something>>();


            for (int i = 0; i< 100000; i++) {
                xis s = new xis();
                s.id = 10;
                tag.Add(s.id, s);
            }
        }
    }

    public class xis {
        public int id;
    }

    public class Lel {
        public int id;
        public List<something> list;
    }

    public class something {
        public int id;
    }
}
