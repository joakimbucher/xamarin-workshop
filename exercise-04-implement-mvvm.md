# Implement MVVM pattern
![](./images/2018-06-21-09-29-39.png)
![](./images/2018-06-21-09-35-10.png)
- Add a add and remove button to the list
- The add button show a new AddTodoItemPage (Use NavigationPage to navigate to the page) 
- The delete button should only be enabled when a todo item is selected
- Use commands and bind it to the buttons
- Store the todo items in a separate service
- Use dependency injection to register and resolve the service in the different ViewModels to avoid dependencies between the ViewModels
- Use the MessageCenter to send loosely coupled notifications to the ViewModels (instead of normal events)


## More information:
- [MVVM Pattern](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/enterprise-application-patterns/mvvm)
- [Simplifying Events with Commanding](https://blog.xamarin.com/simplifying-events-with-commanding/)
- [Build-in DI](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/dependency-service/)
- [MessagingCenter](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/messaging-center)
