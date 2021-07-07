using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars.ViewModels.Public
{
    public class NameIdViewModel<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }

        public NameIdViewModel()
        {
            
        }

        public NameIdViewModel(T id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
