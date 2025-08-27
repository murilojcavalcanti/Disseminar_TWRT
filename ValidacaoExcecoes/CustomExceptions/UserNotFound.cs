namespace ValidacaoExcecoes.WebApp.CustomExceptions
{
    public class UserNotFoundException:Exception
    {
        public UserNotFoundException( string message):base(message)
        {
            
        }
    }
}
