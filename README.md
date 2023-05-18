
# How to simplify data quality management with GraphQl

In today's digital age, data is a crucial component of every organization's operations. However, managing and maintaining data quality can be a daunting task, especially given the sheer volume of data involved. This article will explore how GraphQL can simplify data quality management, and why it is becoming a popular choice for organizations looking to improve their data management practices.

GraphQL is a query language that was developed by Facebook to simplify the process of data fetching and manipulation. It allows developers to specify the data they need and get only that data, rather than having to request all of the data associated with a particular resource. GraphQL has gained popularity in recent years due to its flexibility and ability to reduce data transfer.

Did you know that teams across multiple organizations spend more than half of their time sourcing, maintaining, and debugging errors related to poor data quality? In fact, according to a recent study by Gartner, data-related tasks consume an average of 60% of teams' time in agile development projects. Poor data quality can lead to wasted time, missed deadlines, and increased costs.


## Understanding the Problem

![Payments.png](https://techdojo-digitalgarden.vercel.app/img/user/resources/Payments.png)






To better understand the problem we are solving,  I will illustrate some of the constraints of poor data management through a case study from one of my clients. 

Our client needed to develop a new payment solution that enables users to pay their taxes thru the bank's mobile application, as part of the development, we needed to created test data to simulate valid tax IDs (IRD numbers)

### The challenge

Finding valid Tax numbers was a challenge, since there was only one person in the entire organization who knew how to generate them. This was a massive constraint for our team, since we depended on this person's availability to generate the data for us. We will send emails and follow up through messages waiting from two to three days for him to come back for a few valid tax numbers to find out that some of the tax numbers were already in use by other test accounts.

#### Are you familiar with some of this constraints?

- Dependencies in other teams cause unnecessary delays 
- Legacy data in most the cases is unreliable
- Being a single point of contact creates unnecessary worklog


### Traditional Methods of Managing Data Quality

Every organization has their own unique way to manage data: 

- Keeping a records of data set in Excel files 
- Data sub setting or anonymize 
- Use data virtualization 
- Create data manually 
- In house custom tools 
- Use purchased automation tools

***Do you recognize some of this methods?*** 

What all these methods have in common, is that they are not scalable and they are implemented without any governance. 

Without governance it is difficult to answer the question who is responsible to ensure data quality, or  who should / shouldn't have access to it.


## Solution

Going back to the case study, extracting data was a time consuming task not because its complexity but the dependency with other teams, and when the data was finally made available we still had some invalid tax ids, this back and forth create unnecessary delays. 
  
My goal was to remove the test data creation dependency and have more control in its quality specially if we wanted to implement Test Automation, we needed a way to consistently replicate tax ids.

### how to solve this issue?

Before getting ahead our selves, we needed to understand if there was a tool in the market that solved this problem for us. 

![[Pasted image 20230518231203.png]]
> Note: the above is Magic quadrant with some of the companies that are leading data governance and management in the market.  

Some of this solutions were great but they were not free or cost effective, another challenge was the customization, we needed a solution that adapt to our business not the other way around. 

### GraphQL as Test data Management 

After doing some more research with the requirement in mind about **cost effectiveness** and **flexibility**, we decided to use GraphQL as an abstraction layer for data provisioning. 

The team decided to allocate some time improve the testability of our project, before we could start coding we needed to understand the current state by following the steps bellow. 


#### Step 1: Understand the domain
 
Start  by understanding the domain from which data is being source, depending in your industry the domain might change, for example banking; you might find domains such as payments, credit cards, wealth or portfolio management. 

Remember each domain interact with different source systems or third party vendors, try to understand the domain's data rules and how this is  apply to your project.    

### Identifying business data asset rules

In our case study the domain was wealth, and the domain's data we were looking to replicate was a Tax number, after a chat with the experts in the domain we discover the following: 

- Tax number are 8 to 9 digits long 
- Tax numbers are Unique to customers (Individual or business) 
- Tax numbers can be already be linked to existing customers 

> In today's fast environment documentation falls behind, avoid wasting time reading documents, instead identify SME's (Subject matter experts) and interview them, the information they provide will be more accurate and precise. 

### Step 2: Understanding how to recreate the data 

Once the domain data rules have been identified, its time to understand the process used to provision the data. 

In our case study, Tax number's were created using a macros code inside an excel file, the excel file was store in one of the SME's computer, the file was share couple of times with some people most of them were contractors that were no longer working in the organization.

As we walkthrough the code we discover some improvement opportunities, the main improvement to make this functionality easily available to the rest of the organization.

### Step 3: Implement and Reuse

Once there is an understanding of the business domain and how data is being generated, we can now translate this into requirements to implement a scalable and reusable solution. 

The understanding of business rules help me to define the following use cases: 

* Tax ids without any customer link
* Tax ids linked to customers (Individuals or business)
* A validation for the tax id (between 8 and 9 digits)

the code in the macros file was useful to understand the business rules to generate a more optimum solution consumable thru Graphql 



## Key Results

![Payments-4.png](https://techdojo-digitalgarden.vercel.app/img/user/resources/Payments-4.png)  
The benefits of abstracting data thru GraphQl evident, we removed the dependency on a external team to generate data for us, data was 100% accurate and free of errors, this allow the team to implement Automation testing with the confidence of replicating the right data conditions  based on the identified scenarios. 

### Conclusion 

- Teams and organization can benefit from the flexibility and cost effectiveness of Graphql to drive data quality. 
- Paid tools are still a good alternative, in the event of service virtualization for instance
- GraphQL or any other test data management tool is not a silver bullet solution, this tools are enablement's without the domain experience or the right level of knowledge and accountabilities these tools become worthless   
