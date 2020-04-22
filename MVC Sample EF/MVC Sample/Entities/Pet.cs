using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int OwnerId { get; set; }

        public virtual Person Owner { get; set; }

    }
}
