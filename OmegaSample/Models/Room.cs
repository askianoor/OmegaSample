using OmegaSample.Infrastructure;

namespace OmegaSample.Models
{
    public class Room : Resource
    {
        [Sortable]
        [Searchable]
        public string Name { get; set; }


        [Sortable(Default =true)]
        [SearchableDecimal]
        public int Rate { get; set; }


        public Form Book { get; set; }
    }
}
