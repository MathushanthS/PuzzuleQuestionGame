using PuzzuleQuestion.DbContex;
using PuzzuleQuestion.Helpers;
using PuzzuleQuestion.Helpers.Response;
using PuzzuleQuestion.Model;

namespace PuzzuleQuestion.MediatorQueries.User
{
    public class AddUserCommand :IRequestWrapper<UserModel>
    {
       // public int UserId { get; set; }
        public string? UserName { get; set; }
    }
    public class UserHandler : IHandlerWrapper<AddUserCommand, UserModel>
    {
        private readonly ApplicationDbContext _db;

        public UserHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Response<UserModel>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                
                var user = new UserModel
                {
                    UserName=request.UserName,
                };
               await _db.AddAsync(user);
               await _db.SaveChangesAsync();

               return Response.Ok<UserModel>(user,"Successfully added");
            }
            catch (Exception ex)
            {
                return Response.Fail<UserModel>(ex.Message);
            }
        }
    }
}
