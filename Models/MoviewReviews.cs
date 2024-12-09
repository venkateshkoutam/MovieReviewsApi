using System.ComponentModel.DataAnnotations;

namespace MovieReview.Models
{
    public class MoviewReviews
    {
        [Key]

        public int ID { get; set; }
        public string MovieName { get; set; }

        public string ReviewComments { get; set; }
    }
}
