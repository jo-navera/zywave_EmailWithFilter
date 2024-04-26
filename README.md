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
