I've separated the Presentation Layer from the Web API project to align with Clean Architecture principles. 

The Web API project references other layers to configure middleware, IoC, and related components, 
while the Presentation Layer should only reference the Application Layer. 

This structure also helps prevent junior developers from directly accessing Infrastructure Layer objects, such as DbContext and other similar components.