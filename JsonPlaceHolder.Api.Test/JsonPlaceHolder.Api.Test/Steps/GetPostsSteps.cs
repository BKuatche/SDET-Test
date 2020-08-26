using JsonPlaceHolder.Api.Test.Base;
using JsonPlaceHolder.Api.Test.Helpers;
using JsonPlaceHolder.Api.Test.Models;
using JsonPlaceHolder.Api.Test.Ressources;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace JsonPlaceHolder.Api.Test.Steps
{
    [Binding]
    public sealed class GetPostsSteps
    {
        private readonly RestClientHelper _restClientHelper;
        private readonly Settings _settings;
        private IRestResponse<Posts> _response;
        private IRestResponse<List<Comments>> _responses;

        public GetPostsSteps(RestClientHelper restClientHelper,
            Settings settings)
        {
            _restClientHelper = restClientHelper;
            _settings = settings;
        }

        [Given(@"the user had access to the posts api")]
        public void GivenTheUserHadAccessToThePostsApi()
        {
           _settings.Request= _restClientHelper.GetRestRequest(Constants.Ressource.GetAPostEndpoint);
        }

        [Given(@"the user had access to the get comment api")]
        public void GivenTheUserHadAccessToTheGetCommentApi()
        {
            _settings.Request = _restClientHelper.GetRestRequest(Constants.Ressource.GetCommentsEndpoint);
        }


        [When(@"the user gets the post ""(.*)""")]
        public void WhenTheUserGetsThePost(int id)
        {
            _settings.Request.AddUrlSegment("id", id.ToString());

           _response = _restClientHelper.GetAsync<Posts>(_settings.Request)
                          .GetAwaiter().GetResult();
        }


        [When(@"the user gets comments for the ""(.*)"" post")]
        public void WhenTheUserGetsCommentsForThePost(int postId )
        {
            _settings.Request.AddUrlSegment("postId", postId.ToString());

            _responses = _restClientHelper.GetAsync<List<Comments>>(_settings.Request)
                           .GetAwaiter().GetResult();
        }


        [Then(@"the posts result should be displayed")]
        public void ThenThePostsResultShouldBeDisplayed(Table table)
        {

            var testData = table.CreateInstance<Posts>();

            Assert.Multiple(() =>
            {
                Assert.IsNull(_response.ErrorException);
                Assert.That((int)_response.StatusCode, Is.EqualTo(200));
                Assert.That(_response.Data.id, Is.EqualTo(testData.id));
                Assert.That(_response.Data.title, Is.EqualTo(testData.title));
                Assert.That(_response.Data.userId, Is.EqualTo(testData.userId));

            });
        }

        [Then(@"a status code (.*) should be returned")]
        public void ThenAStatusCodeShouldBeReturned(int statusCode)
        {
            Assert.IsNull(_responses.ErrorException);
            Assert.IsNull(_responses.ErrorMessage);
            Assert.That((int)_responses.StatusCode, Is.EqualTo(statusCode));
        }

        [Then(@"the comments result should be returned")]
        public void ThenTheCommentsResultShouldBeReturned(Table table)
        {
            var actualPostComment =  table.CreateSet<Comments>().ToList();

            for (int i = 0; i <_responses.Data.Count(); i++)
            {
                Assert.That(_responses.Data[i].PostId, Is.EqualTo(actualPostComment[i].PostId));
                Assert.That(_responses.Data[i].Id, Is.EqualTo(actualPostComment[i].Id));
                Assert.That(_responses.Data[i].Name, Is.EqualTo(actualPostComment[i].Name));
                Assert.That(_responses.Data[i].Email, Is.EqualTo(actualPostComment[i].Email));
            }
        }


    }
}
