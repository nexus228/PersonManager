using PersonManager_WPF_CLIENT.Model;

namespace PersonManager_WPF_CLIENT.CustomEventArgs
{
    internal class PersonChangedEventArgs
    {
        public Person Person { get; }

        public PersonChangedEventArgs(Person person)
        {
            Person = person;
        }
    }
}
