using PuzzuleQuestion.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuzzuleQuestion.Model
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public AnswerEnum Answer1 { get; set; }
        public AnswerEnum Answer2 { get; set; }
        public AnswerEnum Answer3 { get; set; }
        public AnswerEnum Answer4 { get; set; }
        public AnswerEnum Answer5 { get; set; }
        public AnswerEnum Answer6 { get; set; }
        public AnswerEnum Answer7 { get; set; }
        public AnswerEnum Answer8 { get; set; }
        public AnswerEnum Answer9 { get; set; }
        public AnswerEnum Answer10 { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel? UserAnswer;


    }
}
