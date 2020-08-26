# SDET-Test



## Report your findings and indicate whether you would sign off the implementation for release into production?

1- the api is not secure

2 - the json response is not in correct format 

  Expected Response
```
   {
  id: 101,
  title: 'foo',
  body: 'bar',
  userId: 1
}

```
Actual Response

```
{
    "userId": 1,
    "id": 1,
    "title": "foo",
    "body": "bar"
}

```
