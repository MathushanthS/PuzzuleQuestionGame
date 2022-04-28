using Microsoft.EntityFrameworkCore;
using PuzzuleQuestion.DbContex;
using PuzzuleQuestion.Helpers;
using PuzzuleQuestion.Helpers.Response;
using PuzzuleQuestion.Model;
using PuzzuleQuestion.Model.Enums;

namespace PuzzuleQuestion.MediatorQueries.AnswerQuery
{
    public class CheckerCommand :IRequestWrapper<int>
    {
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

    public class CheckerHandler : IHandlerWrapper<CheckerCommand, int>
    {
        private readonly ApplicationDbContext _db;

        public CheckerHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Response<int>> Handle(CheckerCommand request, CancellationToken cancellationToken)
        {
            int persontage = 0;
            try
            {
                var result = await (from p in _db.Answers

                                    where p.UserId == request.UserId
                                    select new Answer
                                    {
                                        AnswerId = p.AnswerId,
                                        Answer1 = p.Answer1,
                                        Answer2 = p.Answer2,
                                        Answer3 = p.Answer3,
                                        Answer4 = p.Answer4,
                                        Answer5 = p.Answer5,
                                        Answer6 = p.Answer6,
                                        Answer7 = p.Answer7,
                                        Answer8 = p.Answer8,
                                        Answer9 = p.Answer9,
                                        Answer10 = p.Answer10,
                                        UserId = p.UserId,


                                    }).FirstOrDefaultAsync();
                if (request.Answer1==result.Answer1)
                    persontage =persontage+1;
                if (request.Answer2==result.Answer2)
                    persontage = persontage + 1;
                if (request.Answer3 == result.Answer3)
                    persontage = persontage + 1;
                if (request.Answer4 == result.Answer4)
                    persontage = persontage + 1;
                if (request.Answer5 == result.Answer5)
                    persontage = persontage + 1;
                if (request.Answer6 == result.Answer6)
                    persontage = persontage + 1;
                if (request.Answer7 == result.Answer7)
                    persontage = persontage + 1;
                if (request.Answer8 == result.Answer8)
                    persontage = persontage + 1;
                if (request.Answer9 == result.Answer9)
                    persontage = persontage + 1;
                if (request.Answer10 == result.Answer10)
                    persontage = persontage + 1;
                int finalResult = persontage * 10;
                //eturn Response.ok<>finalResult;




               return Response.Ok<int>(finalResult,"Matching Calculated");
            }
            catch (Exception ex)
            {
                return Response.Fail<int>(ex.Message);
            }
        }
    }
}
