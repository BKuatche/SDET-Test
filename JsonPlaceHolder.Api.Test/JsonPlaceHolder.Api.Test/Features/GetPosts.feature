Feature: GetPosts


	As a user
	I want to be able to get posts and comment


Scenario: Get a post
	Given the user had access to the posts api
	When the user gets the post "1"
	Then a status code 200 should be returned
	     And the posts result should be displayed
	     | userId | id | title                                                                      |
	     | 1      | 1  | sunt aut facere repellat provident occaecati excepturi optio reprehenderit |


 Scenario: Get Comment for a post
	Given the user had access to the get comment api
	When the user gets comments for the "1" post
	Then a status code 200 should be returned
	    And the comments result should be returned
		   | PostId | Id | Name                                      | Email                  |
		   | 1      | 1  | id labore ex et quam laborum              | Eliseo@gardner.biz     |
		   | 1      | 2  | quo vero reiciendis velit similique earum | Jayne_Kuhic@sydney.com |
		   | 1      | 3  | odio adipisci rerum aut animi             | Nikita@garfield.biz    |
		   | 1      | 4  | alias odio sit                            | Lew@alysha.tv          |
		   | 1      | 5  | vero eaque aliquid doloribus et culpa     | Hayden@althea.biz      |