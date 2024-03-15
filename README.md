# Customers API

![GitHub repo size](https://img.shields.io/github/repo-size/iuricode/README-template?style=for-the-badge)
![Bitbucket open issues](https://img.shields.io/bitbucket/issues/iuricode/README-template?style=for-the-badge)
![Bitbucket open pull requests](https://img.shields.io/bitbucket/pr-raw/iuricode/README-template?style=for-the-badge)

> This project aims to create a REST API CRUD for customers, utilizing an object list to store data and allowing custom inserts without the use of pre made sorting methods.
> Additionally, it includes a console simulator where you can specify the number of requests and customers per request, enabling parallel request execution.

### Improvements

Some areas for improvement are:

- [x] Integrated Simulator
- [x] All CRUD methods
- [x] Correct HTTP responses 
- [ ] Implement a Queue to access the file 
- [ ] Databse to store data

## 💻 Requirements

Before starting, please ensure you have met the following requirements:

- .NET 6 installed
- Postman ( or similar)

## ☕ Using Customers API

To use this project, follow the guide:

```
1. Clone the repository
2. Run the CustomerAPI project (defaultPorts: 7179 - HTTPS and 5094 - HTTP
3. Import the postman JSON from the docs inside your local Postman
4. Update the base URL port (if necessary)
5. Send the requests and manage the Customers!
```
If you want to run the API and the Simulator
```
1. Clone the repository
2. Go to "Set startup Projects" and Set both projects to run (CustomerAPI and CustomerApiSimulator)
3. When you run the projects, both the server side application and a console application um run
4. On the simulator console, insert the number of request you want to send in parallel
5. Then insert the number os Customers you want the simulator to send in each request
6. It will send all request in pararrel, and then you can repeat the process
7. You can also use the postman collection in this scenario
8. You can also access the object file in CustomerAPI/CustomerData.json
```
![image](https://github.com/Leonardo3Morais7/CustomerAPI/assets/36652975/a49f5acf-d145-4d65-b1a9-44a995284165)



