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

            //ObservableList2<string> carCompterEvent = new ObservableList2<string>();

            //carCompterEvent.Add2eventlog += new ObservableList2<string>.Add2Handler(DisplayInformation);
            //carCompterEvent.Update2eventlog += new ObservableList2<string>.Update2Handler(DisplayInformation);
            //carCompterEvent.Delete2eventlog += new ObservableList2<string>.Deleted2Handler(DisplayInformation);

            //carCompterEvent.Add("element 0");
            //carCompterEvent.Add("element 1");
            //carCompterEvent.Add("element 2");
            //carCompterEvent.Add("element 3");
            //carCompterEvent.Set(0,"zmieniony");
            //carCompterEvent.RemoveAt(2);
            //for(int i=0; i < carCompterEvent.lenght; i++)
            //{
            //    carCompterEvent.Get(i);
            //}
            string dest = "test";
            ObservableList2<string> list_lambda = new ObservableList2<string>();
            del Add = x => list_lambda.Add(dest);
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

        del Add = x => container.Add(x);
        // A method that adds strings to the collecti
        // on.

        //  Add(5);
        // OnAddtolist(str);


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
            if (Add2eventlog != null)
            {
                Add2eventlog(information);
            }
        }
        protected void OnDelete2eventlog(string information)
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
        public int lenght { get { return container.Count; } }

    }
}