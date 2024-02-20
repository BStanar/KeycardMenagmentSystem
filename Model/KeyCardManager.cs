using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Model
{
    public class KeyCardManager
    {
        public static ObservableCollection<Keycard> _DatabaseKeyCards = new ObservableCollection<Keycard>() { };
        public static ObservableCollection<Keycard> GetKeyCards()
        {
            PopulateDummyData();
            return _DatabaseKeyCards;
            

        }


        public static void AddKeyCard(Keycard keycard)
        {
            _DatabaseKeyCards.Add(keycard);

        }

        public static void PopulateDummyData()
        {
            Employee employee1 = new Employee(1, "Doe", "john@example.com", "John", "password123", "johndoe", DateTime.Now);
            Employee employee2 = new Employee(2, "Smith", "jane@example.com", "Jane", "password456", "janesmith", DateTime.Now);

            Keycard keycard1 = new Keycard(1, "ABC123", employee1);
            Keycard keycard2 = new Keycard(2, "DEF456", employee2);
            

           
            

            AddKeyCard(keycard1);
            AddKeyCard(keycard2);
            
        }

        public ObservableCollection<Keycard> FindByEmployeeName(string Name)
        {
            ObservableCollection<Keycard> CardsByName = new ObservableCollection<Keycard>() { };

            foreach(var card in _DatabaseKeyCards)
            {
                if(card.Employee.FirstName.Contains(Name)) CardsByName.Add(card);
            }
            return CardsByName;

        }

        public static void RemoveKeycardById(int id)
        {
            int i=0;
            foreach(var keycard in _DatabaseKeyCards)
            {
                if (id.Equals(keycard.KeycardID)) break; i++;
            }
            _DatabaseKeyCards.RemoveAt(i);
        }
    }
}
