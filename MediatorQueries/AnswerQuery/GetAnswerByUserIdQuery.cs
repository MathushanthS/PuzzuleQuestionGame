using Microsoft.EntityFrameworkCore;
using PuzzuleQuestion.DbContex;
using PuzzuleQuestion.Helpers;
using PuzzuleQuestion.Helpers.Response;
using PuzzuleQuestion.Model;

namespace PuzzuleQuestion.MediatorQueries.AnswerQuery
{
    public class GetAnswerByUserIdQuery :IRequestWrapper<Answer>
    {
        public int UserId { get; set; }
    }
    public class GetAnswerByUserIdHandler : IHandlerWrapper<GetAnswerByUserIdQuery, Answer>
    {
        private readonly ApplicationDbContext _db;

        public GetAnswerByUserIdHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Response<Answer>> Handle(GetAnswerByUserIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await GetAnswerById(request.UserId);
                return Response.Ok<Answer>(result,"you got");
            }
            catch (Exception ex)
            {
                return Response.Fail<Answer>(ex.Message);
            }
        }

        public async Task<Answer> GetAnswerById(int? Id)
        {
            
                var result = await (from p in _db.Answers

                                    where p.UserId == Id
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
                                        UserId = p.UserId
                                        

                                    }).FirstOrDefaultAsync();
            
                return result;
        }
    }
}
