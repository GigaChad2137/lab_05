using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace lab_05
{

    public class Program
    {
        static void DisplayInformation(string info)
        {
            Console.WriteLine(info);
        }
        public static void Main()
        {
            //ObservableList1<string> observablelist1 = new ObservableList1<string>();
            //observablelist1.Add("test 0 ");
            //observablelist1.Add("test 1 ");
            //observablelist1.Add("test 2 ");
            //observablelist1.Add("test 3 ");
            //observablelist1.Add("test 4 ");
            //observablelist1.Set(1,"bałkany ");
            //observablelist1.RemoveAt(0);
            //for(int i=0; i < observablelist1.lenght; i++)
            //{
            //    observablelist1.Get(i);
            //}

            // ObservableList2<string> observablelist2 = new ObservableList2<string>();
            //observablelist2.Add2eventlog += new ObservableList2<string>.Add2Handler(DisplayInformation);
            //observablelist2.Update2eventlog += new ObservableList2<string>.Update2Handler(DisplayInformation);
            //observablelist2.Delete2eventlog += new ObservableList2<string>.Deleted2Handler(DisplayInformation);

            //observablelist2.Add("element 0");
            //observablelist2.Add("element 1");
            //observablelist2.Add("element 2");
            //observablelist2.Add("element 3");
            //observablelist2.Set(0,"zmieniony");
            //observablelist2.RemoveAt(2);
            //for(int i=0; i < observablelist2.lenght; i++)
            //{
            //    observablelist2.Get(i);
            //}

            //ObservableList3<string> observableList3 = new ObservableList3<string>();
            //observableList3.Add("do usuniecia");
            //observableList3.RemoveAt(0);
            //observableList3.Add("tescior");
            //observableList3.Add("tescior");
            //observableList3.Add("tescior");
            //observableList3.Add("tescior");
            //observableList3.Add("tescior");
            //observableList3.Add("tescior");

            //for(int i =0;i< observableList3.lenght; i++)
            //{
            //    observableList3.Get(i);
            //}
             ObservableList1_lambda<string> observablelist1_lambda = new ObservableList1_lambda<string>();
          
        }

    }
    class ObservableList1<T>
    {
        public delegate void NumberManipulationHandler();
        public delegate string Message(int index,T value);

        // Define a delegate to handle string display.
        public event NumberManipulationHandler Added;
        public event NumberManipulationHandler Updated;
        public event NumberManipulationHandler Deleted;
        protected virtual void OnAddtolist(T str)
        {
            if (Added != null)
                Added();
            else

                Console.WriteLine($"Dodano {str} ");
        }
        protected virtual void OnUpdatetolist(int index,T str)
        {
            if (Updated != null)
                Updated();
            else
                Console.WriteLine($"Zaktualizowano element index: {index} value: {str} ");
        }
        protected virtual void OnRemovetolist(int index)
        {
            if (Deleted != null)
                Deleted();
            else
                Console.WriteLine($"Usunięto element z index: {index} ");
        }
        // A generic list object that holds the strings.
        private List<T> container = new List<T>();

        // A method that adds strings to the collection.
       
        internal void Add(T str)
        {

            container.Add(str);
            OnAddtolist(str);
        }
        internal void RemoveAt(int index)
        {
            container.RemoveAt(index);
            OnRemovetolist(index);


        }
        internal void Set(int index, T value)
        {
            this.container[index] = value;
            OnUpdatetolist(index, value);
        }
        internal void Get(int index)
        {
          T value =  this.container[index] ;
            Message whatuget = (int index , T value) =>
            {
                return $"Element mający index: {index} value: {value}";
            };
            Console.WriteLine(whatuget(index, value));
           
        }
        

        public int lenght { get { return container.Count; } }
           
     

    }
    class ObservableList1_lambda<T>
    {
        public delegate void NumberManipulationHandler();
        public delegate string Message(int index, T value);
        public delegate string Messa();
        // Define a delegate to handle string display.
        public event NumberManipulationHandler Added;
        public event NumberManipulationHandler Updated;
        public event NumberManipulationHandler Deleted;
        public delegate T del(T str);

     

        protected virtual void OnAddtolist(T str)
        {
            if (Added != null)
                Added();
            else

                Console.WriteLine($"Dodano {str} ");
        }
        protected virtual void OnUpdatetolist(int index, T str)
        {
            if (Updated != null)
                Updated();
            else
                Console.WriteLine($"Zaktualizowano element index: {index} value: {str} ");
        }
        protected virtual void OnRemovetolist(int index)
        {
            if (Deleted != null)
                Deleted();
            else
                Console.WriteLine($"Usunięto element z index: {index} ");
        }
        // A generic list object that holds the strings.
        private List<T> container = new List<T>();


        // A method that adds strings to the collecti
        // on.

        //  Add(5);
        // OnAddtolist(str);
        Messa sayHello = () => "Hello!!!";
        internal void Add(T str)
        {

            container.Add(str);
            OnAddtolist(str);
        }
        internal void RemoveAt(int index)
        {
            container.RemoveAt(index);
            OnRemovetolist(index);


        }
        internal void Set(int index, T value)
        {
            this.container[index] = value;
            OnUpdatetolist(index, value);
        }


        internal void Get(int index)
        {
            T value = this.container[index];
            Message whatuget = (int index, T value) =>
            {
                return $"Element mający index: {index} value: {value}";
            };
            Console.WriteLine(whatuget(index, value));

        }


        public int lenght { get { return container.Count; } }



    }

    class ObservableList2<T>
    {
        public delegate void Add2Handler(string add);
        public event Add2Handler Add2eventlog;
        public delegate void Update2Handler(string add);
        public event Update2Handler Update2eventlog;
        public delegate void Deleted2Handler(string add);
        public event Deleted2Handler Delete2eventlog;
        public delegate string Message(int index, T value);
        // A generic list object that holds the strings.
        private List<T> container = new List<T>();
        // A method that adds strings to the collection.
        internal void Add(T str)
        {
            container.Add(str);
            OnAdd2eventlog($"Dodano {str} ");
        }
        internal void RemoveAt(int index)
        {
            container.RemoveAt(index);
            OnDelete2eventlog($"Usunięto element na pozycji: {index} ");
        }
        internal void Set(int index, T value)
        {
            this.container[index] = value;
            OnUpdate2eventlog($"Zaaktualizowano index: {index} value: {value} ");
        }
        internal void Get(int index)
        {
            T value = this.container[index];
            Message whatuget = (int index, T value) =>
            {
                return $"Element mający index: {index} value: {value}";
            };
            Console.WriteLine(whatuget(index, value));

        }
        protected void OnAdd2eventlog(string information)
        {
            // Add2eventlog to nasze zdarzenie, które jest zdefiniowane na podstawie 
            // istniejącego delegata Add2Handler
            // Delegat ten jest sygnaturą metody, króra jest wykorzystywna w naszym zdarzeniu
            // Dlatego też, jako parametr naszego zdarzenia przekazujemy 'string'
            if (Add2eventlog != null)
            {
                Add2eventlog(information);
            }
        }
        protected void OnUpdate2eventlog(string information)
        {
            // Add2eventlog to nasze zdarzenie, które jest zdefiniowane na podstawie 
            // istniejącego delegata Add2Handler
            // Delegat ten jest sygnaturą metody, króra jest wykorzystywna w naszym zdarzeniu
            // Dlatego też, jako parametr naszego zdarzenia przekazujemy 'string'
            if (Update2eventlog != null)
            {
                Update2eventlog(information);
            }
        }
        protected void OnDelete2eventlog(string information)
        {
            // Add2eventlog to nasze zdarzenie, które jest zdefiniowane na podstawie 
            // istniejącego delegata Add2Handler
            // Delegat ten jest sygnaturą metody, króra jest wykorzystywna w naszym zdarzeniu
            // Dlatego też, jako parametr naszego zdarzenia przekazujemy 'string'
            if (Delete2eventlog != null)
            {
                Delete2eventlog(information);
            }
        }
        public int lenght { get { return container.Count; } }

    }
    class ObservableList3<T>
    {
        public delegate string Updated(int index, T value);
        public delegate string Added(T value);
        public delegate string Removed(int message);
        public delegate string Message(int index, T value);
        private List<T> container = new List<T>();
        internal void Add(T str)
        {
            container.Add(str);
            Added added = (T str) =>
            {
                return $"Dodano {str} ";
            };
            Console.WriteLine(added(str));
        }
        internal void RemoveAt(int index)
        {
            container.RemoveAt(index);
            Removed updated = (int index) =>
            {
                return $"Usunięto element z index: {index} ";
            };
            Console.WriteLine(updated(index));
        }
        internal void Set(int index, T value)
        {
            this.container[index] = value;
            Updated updated = (int index, T value) =>
            {
                return $"Zaktualizowano element index: {index} value: {value} ";
            };
            Console.WriteLine(updated(index, value));
        }
        internal void Get(int index)
        {
            T value = this.container[index];
            Message whatuget = (int index, T value) =>
            {
                return $"Element mający index: {index} value: {value}";
            };
            Console.WriteLine(whatuget(index, value));
        }
        public int lenght { get { return container.Count; } }



    }
}