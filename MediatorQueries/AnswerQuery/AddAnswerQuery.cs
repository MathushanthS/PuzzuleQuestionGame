using PuzzuleQuestion.DbContex;
using PuzzuleQuestion.Helpers;
using PuzzuleQuestion.Helpers.Response;
using PuzzuleQuestion.Model;
using PuzzuleQuestion.Model.Enums;

namespace PuzzuleQuestion.MediatorQueries.AnswerQuery
{
    public class AddAnswerQuery : IRequestWrapper<Answer>
    {
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
    }
    public class AddAnswerHandler : IHandlerWrapper<AddAnswerQuery, Answer>
    {
        private readonly ApplicationDbContext _db;

        public AddAnswerHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Response<Answer>> Handle(AddAnswerQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var ans = new Answer()
                {
                    AnswerId = request.AnswerId,
                    Answer1 = request.Answer1,
                    Answer2 = request.Answer2,
                    Answer3 = request.Answer3,
                    Answer4 = request.Answer4,
                    Answer5 = request.Answer5,
                    Answer6 = request.Answer6,
                    Answer7 = request.Answer7,
                    Answer8 = request.Answer8,
                    Answer9 = request.Answer9,
                    Answer10 = request.Answer10,
                    UserId = request.UserId,

                        
                    };
                    var result = await AddAsync(ans);
                   
                    return Response.Ok<Answer>(ans, "Success");
                
               
            }
            catch (Exception ex)
            {
                return Response.Fail<Answer>(ex.Message);
            }

        }
        public async Task<Answer> AddAsync(Answer answer)
        {
            await _db.AddAsync(answer);
            await _db.SaveChangesAsync();
            return answer;
        }
    }

   
}
