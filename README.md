# Additional Comments

Space time estimations are comented in code

Given the simplicty of this implementation, i'd consider using a serverles aproach(azure function, AWS Lambda, etc).

any cloud automated strategy for deploying would be good, I can generalize the process I typically follow.
-[1]Hooks/Api integrations for fetching source code.
-[2]Agent to process build/tests.
-[3]Agent to analyze code standard.
-[4]Agent to deploy code/infrasctructure.

For big inputs I would use asycronous programming, and maybe try to user another algorithm to sort by color.