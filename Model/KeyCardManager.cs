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
            Users employee1 = new Users(1, "Doe", "john@example.com", "John", "password123", "johndoe", DateTime.Now,"Employee");
            Users employee2 = new Users(2, "Smith", "jane@example.com", "Jane", "password456", "janesmith", DateTime.Now, "Employee");

            Keycard keycard1 = new Keycard(1, "ABC123", employee1.ID);
            Keycard keycard2 = new Keycard(2, "DEF456", employee2.ID);
            

           
            

            AddKeyCard(keycard1);
            AddKeyCard(keycard2);
            
        }

        public void FindByEmployeeName(string Name)
        {
            
           

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
