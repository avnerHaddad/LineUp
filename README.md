# LineUp
creates a shavzak for DirtyDance Team

this shit is unironically pretty dogwater now
how it works though is something like this could change later:

# todolist
 ## lets keep this updated and shit
### currently doing
 *listitem
 *listItem
### todo list db
 
 * update the gitignore and remove all the bullshit here
 * decide if we delete day class and replace it with a 7*4 grid of shifts
 * make backtracking save all solved boards then rank them for best to worst and return tem from a stack that user can pop each time in fe
 * each person has a score to each shift
   defults to 0
   1 if he likes it
   0 indifferent to it
   -1 if he dosnt like it
when we create a shavzak we can score it if we sum up all getPersonsPreference(shift, shift.currentPerson)
we need to figure out the correct way to datastructure it nicely tho
 * implement more constraints
 * implement prequesites
 * create a better tostring for the shavzak class as stated in documentation
 * make shavzak maker hold the previous shavzak
 * update propegateconstraints function to work like in the documentation
 * add input checking
 * add an option for backtracking to realise when it is unsolvable and return the closest thing to solved
 * fe should have option to login to all users each user can enter his own conditions, 133rikod can enter for everyone and edit it all
 * generating a shavzak can only be done through 133rikod
 
 
 

# Person class
represents a person that is supposed to take shifts
why is it usefull?
* maybe we want to define shifts he cannot take before we run the shavzak?
* maybe we want to define the max amount of shifts the person can take while the algrithem shifts him
* generally makes it easier to manage then to just use a list of string in the ShavzakCreator Class\
* you get the point now

# Shift Class
is the equiveelent of cell class in a sudoku solver
it basically holds a list of <Person> called possibilities(which are deduced using diferent constraints, more on that later)
it also holds the person that is currently shifted and if there is someone like that. 
usefull stuff indeed


# Day Class
a day is a list of Shifts, it  contatins all of the shifts that can be in that day
currently we are talking about mornning shift, evening shift, night shift and konanut shift
now this is a class where the neccisty of it is not completely clear dowe really need to represent a shavzak as a list of days with shifts? maybe we could just use a 7*4 grid filled with shifts and it would be better?
as i said this code  is still in early stages and we can still think about it and decide. a good point for why this might be good is that some logics might need to know the day itself, for example seeing who was last sofash, we can still just subsitute it with indexes in a grid though. as i am wrtiting this i am starting to realise how a day class is actually a pretty shit idea but we will see

# Shavzak Class
this class represents a shavzak, a full one, it contains a list of <Day>(currently) and has list of people that can-be/are shifted in it
it has function to load and write itself to json, (a feature that needs to be tests and decided in more detail on how we would like to use it)(todo)
its got a pretty shitty toString function that works for the time being to debug, but could really use a more modular approuch where we cal to toString on each object this DataStructure contains and combine them(todo)


# IConstraint
a simple interface representing  a constraint, it  only has one function     public bool RunConstraint(Shavzak shavzak)
the function gets the shavzak we are currently "solving" applies some sort of logic on it, and thus deduces the possibilites in it/fills in persons in certain shifts



# ShavzakCreator
this is the class where all the magic happens
* holds a new Shavzak object that is initialised with possibilities and is ready to be filled
* will hold the previous shavzak object(maybe a list of few previous ones) and will use it to eliminate some certain possibilities in the new shavzak(todo)
* has a few functions that serve as the main algorithem so lets not waste time:

     * ## private void RunPrerequisites()
       this function runs all of the one time constraints we want to use at the start of the algorithem for example:
       *  a constraint that removes all of the people in the previous sofash from the current ones possibilities
       *  a constraint that removes someone from possibilites in the days he cannot take for some specific reason

    * ##     private bool PropagateConstraints(Shavzak newShavzak)
        this function is called by the backtracking algorithem every time we fill in a new cell
        this function runs all of our constraints and tries to deduce the possibilities as much as possible
        this function works by running the most simple constraint then gradually trying the harder ones, once one constraint fills a shift then we run it again from the start(todo)
  * ##     private Shavzak TakeAGuess(Shavzak newShavzak)
        this function is what we use once we exhaust all constraints we fill in the first empy shift with the first available possibilty
        this function would probably work better if it was random we should consider changing it(todo)
    
  * ##     private Shavzak BackTracking(Shavzak newShavzak)
    ### i-it-it-it's just like sudoku!
          this function works like backtracking in sudoku
          hopefully you are not a brainrotted idiot and didnt use DaNciNg lINkS so you already know how it works
          if you did though then listen up(i feel sorry for you)
    
          *run constraints
          *check if the board is solved?(filled in all cells) ---yes--> return it
                                |
                                |no
                                v
                        * can we fill up more cells? ------
                      /                                    \
                    /no                                      \yes
                  v                                           \
        return in the recusion and continue to the next guess     \
                                                                    v
                                                                guess the first cell from a list of available guesses and call the function again recursivly
    
    

  hope this helps
  also because this is a pretty early version of the project this is only how backtracking works in theory, in the project we dont have a next guess in case we fail and we dont go back the stack trace if there is no option to fill anymore(todo)

# The Constraints

this is all of the constraints our project has/will have

 ## TwiceInTheSameDay
  #### current status: implemented
     this constraints removes someonoe from all possibilites of a certain day if he is filled in one of the day's shifts
## addSomeMoreLater
