## API USE
## User
#### To get user

```http
  GET https://localhost:xxxx/api/users
(xxxx=your port number)
```


#### To get user by id

```http
  GET https://localhost:xxxx/api/users/{id}
```

#### To create user

```http
  POST https://localhost:xxxx/api/users
  Json raw:
{      "emailAdress": "xxxxx@ssttek.com",
        "firstName": "xxx",
        "lastName": "xxx"
}


```
#### To delete user by id

```http
  DELETE https://localhost:xxxx/api/users/{id}
```


#### To update user by id

```http
  PUT https://localhost:xxxx/api/users/{id}
 Json raw:
{      "emailAdress": "xxxxx@ssttek.com",
        "firstName": "xxx",
        "lastName": "xxx"
}


```
## Mail

#### To get mails
```http
  GET https://localhost:xxxx/api/mails
```


#### To get mails by id

```http
  GET https://localhost:xxxx/api/mails/{id}
```

#### To create mail

```http
  POST https://localhost:xxxx/api/mails
  Json row:
{
        "toEmail": "ayilmaz@ssttek.com",
        "message": "Merhaba"
}
(fromEmail is constant value, mail is sent only to e-mail addresses defined as users.)


```
#### To delete mail by id

```http
  DELETE https://localhost:xxxx/api/mails/{id}
```
