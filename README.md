# QA-HelperTools
Nb: At the time of coding didn't followed any Coding Style Guidelines. Please do consider this as a free time work. (Will do refactor/refine the code, going forward)


### How to use :

1. Click on the "Check_PreCondition-v2.exe", the tool will launch with the following UI:
![Sample Tool UI](https://github.com/ajith-geon/QA-HelperTools/blob/master/Sample/Sample-Tool%20UI.png?raw=true)

2. Provide Test-Rail Username and Password.

3. Fill the Test Plan ID: text box with the TestRail TestPlan's id (on which you need to run a check for the missing pre-conditions). When you select the ID, do ignore the preceding "R". In the below snapshot, the TestPlan id to be used is 22768.
![Sample-Run Details](https://github.com/ajith-geon/QA-HelperTools/blob/master/Sample/Sample-ImageTestRun2.jpg?raw=true)

4. Click on "Identify Missing Pre-condtions in Plan".

5. Once the run is complete, a csv log file is created in the "Output" folder which shows the following:

### Results :

Parent Case (First column): The case id of an Automated case which is included in this plan, but whose pre-condition is missing. 

Missing Pre-condition (Second Column) : The test case id of the pre-condition which is missing from this plan.

Suite (Third Column) : The Suite name of the pre-condition case.

Path (Fourth Column) : The path (inside the Suite) where we can find the pre-condition to be included.
