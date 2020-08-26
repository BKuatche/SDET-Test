namespace JsonPlaceHolder.Api.Test.Ressources
{
    public class Constants
    {
        public class Ressource
        {
            public const string BaseUrl = "https://jsonplaceholder.typicode.com/";
            public const string GetAllPostsEndpoint = "posts";
            public const string GetAPostEndpoint = "posts/{id}";
            public const string GetCommentsEndpoint = "posts/{postId}/comments";
        }
    }
}
