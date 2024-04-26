# Zywave Technical Assignment 
 Please complete the following technical assignment. You can complete the project in any technology or language you choose. However, the solution must be suitable for a demo and be able to be reviewed at a source code level using standard text editing tools. 
## CLASSIFIED EMAIL FILTER 
You have been hired by a company to write software to detect potential classified mail being exchanged in non-secure email accounts. Your software will act as a filter to test the incoming email text, detect if the email might be classified, and additionally replace any sensitive text with censored ***** characters. 
Please write the core code as a function that accepts as parameters: 
-	a list of classified words/phrases 
-	the email text 
The function should return:
-	true/false flag - If any of the classified words or phrases were located in the email 
-	censored text – a new email text where the classified words or phrases have been replaced with asterisks, or the original email text if there was no classified material in the email  

Around the core function you can write a wrapper of your choice that lets a user input test data, run the function, and see the result. 

If the requirements are unclear, just capture what the point of confusion was, what assumptions you made, and why. Keep the list to talk through later. 

 
**Bonus: Develop, pseudo code or describe in detail how to implement this function into an email messaging system.**

## Assumptions
- Text filtering is only needed for email body
- Text filtering is going to be processed by default (this can be set via a config in the future as necessary)
- Censored words are defined by default in the back end if no input is received
- Exception will be fired if no text to be filtered is received
- Unit tests and exception handling are only samples and can/should be extended in the real world
- API/Swagger are used for easier manual testing

## Email processing with filters
- The provided email sending is a very basic suggestion of sending emails
- The preferred approach of the candidate is the following:
  1. Receive email requests and queue them to an event bus
   - This should automatically log the request parameters
  2. Trigger text filter from email request bus
   - This translates the original email text to a filtered text
  3. A request with the filtered text is sent to the email service for the actual sending of email
  
  
  
