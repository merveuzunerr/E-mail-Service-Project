## API Kullanımı
## User
#### To get User

```http
  GET /api/users
```


#### To get user by id

```http
  GET api/users/{id}
```

#### To create user

```http
  POST api/users
  Json raw:
{      "emailAdress": "xxxxx@ssttek.com",
        "firstName": "xxx",
        "lastName": "xxx"
}


```
#### To delete user by id

```http
  DELETE api/users/{id}
```


#### To update user by id

```http
  PUT api/users/{id}
 Json raw:
{      "emailAdress": "xxxxx@ssttek.com",
        "firstName": "xxx",
        "lastName": "xxx"
}


```
## Mail

#### To get mails
```http
  GET api/mails
```


#### To get mails by id

```http
  GET api/mails/{id}
```

#### To create mail

```http
  POST api/mails
  Json row:
{
        "toEmail": "ayilmaz@ssttek.com",
        "message": "Merhaba"
}
(fromEmail is constant value)


```
#### To delete mail by id

```http
  DELETE api/mails/{id}
```
