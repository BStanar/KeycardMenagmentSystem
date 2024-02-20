using KeycardMenagmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.ViewModel
{
    public class KeyCardListViewModel
    {
        public ObservableCollection<Keycard> Keycards { get; set; }

        public KeyCardListViewModel() {
            Keycards = KeyCardManager.GetKeyCards();
        
        }

        public void AddKeycard(Keycard keycard)
        {
            KeyCardManager.AddKeyCard(keycard);
            Keycards=KeyCardManager.GetKeyCards();
        }

        public void RemoveKeycardById(int id)
        {
            KeyCardManager.RemoveKeycardById(id);
            Keycards = KeyCardManager.GetKeyCards();    
        }

    }
}
