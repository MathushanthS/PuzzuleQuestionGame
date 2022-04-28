using System.ComponentModel.DataAnnotations;

namespace PuzzuleQuestion.Model
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual Answer? Answer { get; set; }

    }
}
