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
            //PopulateDummyData();
            return _DatabaseKeyCards;
            

        }


        public static void AddKeyCard(Keycard keycard)
        {
            _DatabaseKeyCards.Add(keycard);

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
