using PersonManager_WPF_CLIENT.Model;

namespace PersonManager_WPF_CLIENT.CustomEventArgs
{
    internal enum PersonChangedEventIdentifier
    {
        UNSPECIFIED, CREATED, UPDATED, DELETED
    }

    internal class PersonChangedEventArgs
    {
        public PersonChangedEventIdentifier Identfier
        {
            get;
        }

        public Person Person { get; }

        public PersonChangedEventArgs(Person person, PersonChangedEventIdentifier identifier)
        {
            Person = person;
            Identfier = identifier;
        }
    }
}
