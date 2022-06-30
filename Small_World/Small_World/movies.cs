using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Small_World
{
    public class Movie_Actors
    {
        public string movieName;
        public List<string> FilmActors;
        public Movie_Actors()
        {
            FilmActors = new List<string>();
        }
    }
    public class Queries
    {
        public string Actor1, Actor2;
       
    }
    //public class construct_Graph
    //{
    //    static List<int>[] adjacents;
    //    //static List<KeyValuePair<string, List<string>>> adjacents = new List<KeyValuePair<string, List<string>>>();
    //    static Queue<string> Q = new Queue<string>();
    //    static string secondActor;
    //    int time = 0;
    //    static string[] color;
    //    static string[] parent;
    //    static int[] discovery_Time;
    //    //public static Dictionary<int, HashSet<int>> Adj = new Dictionary<int, HashSet<int>>();
       
    //    public static Dictionary<string, int> ActorID = new Dictionary<string, int>();
    //    //public static Dictionary<int,string> Actorname = new Dictionary<int, string>();
    //    //public static HashSet<KeyValuePair<int, int>> movieFile = new HashSet<KeyValuePair<int, int>>();
        
    //    public static void initialize_gragh(HashSet<string> Actors)
    //    {
            
    //        color = new string[Actors.Count];
    //        parent = new string[Actors.Count];
    //        discovery_Time = new int[Actors.Count];
    //        List<string> ActorsList = Actors.ToList();//convert HashSet Of ACtor To list
    //        int index;
    //        for (int i = 0; i < ActorsList.Count; i++)
    //        {
    //            ActorID.Add(ActorsList[i], i);
    //            //Actorname.Add(i, ActorsList[i]);
    //            color[i] = "white";
    //            //discovery_Time[i] = -1;
    //            parent[i] = null; 

    //        }
    //        color[0] = "gray";
    //        discovery_Time[0] = 0;
    //        parent[0] = null;
            
    //    }
       
    //    //public static void BFSGraph(HashSet<string> actors, HashSet<KeyValuePair<string, string>> Movie_File, string Firstactor)
    //    //{
           
    //    //    List<string> newActor = actors.ToList();
           
    //    //    adjacents = new List<int>[newActor.Count];
            
    //    //    List<string> li; //list 3alshan tshl el ta5zen f el adjacent
          
    //    //    for (int i = 0; i < newActor.Count; i++) { 
    //    //    adjacents[i]=new List<int>();//adjacent
    //    //    }
            
    //    //    initialize_gragh(actors);
    //    //    Q.Enqueue(Firstactor);
    //    //    // 3ayzen nghyr rl Movie_File le arkam bdl string w n7utu fe movieFile 
    //    //    // mafrod ageb el id mn actorID 
            
    //    //    //List<int> adjacent;
    //    //    foreach(var adj in Movie_File)
    //    //    { 
                
    //    //        int ind1 = ActorID[adj.Key];
    //    //        int ind2 = ActorID[adj.Value];
                
    //    //        adjacents[ind1].Add(ind2);
    //    //        adjacents[ind2].Add(ind1);
                
    //    //    }
    //    //    Console.WriteLine("first loop");
    
    //    //    while (Q.Count != 0)
    //    //    {
    //    //        secondActor = Q.Dequeue();
    //    //        int ind = newActor.IndexOf(secondActor);
    //    //        foreach (int v in adjacents[ind])
    //    //        {
    //    //            //int x = newActor.IndexOf(v.ToString());
    //    //            if (color[v] == "white")
    //    //            {
    //    //                color[v] = "gray";
    //    //                discovery_Time[v] = discovery_Time[ind] + 1; 
    //    //                parent[v] = secondActor;
    //    //                Q.Enqueue(newActor[v]);
    //    //            }
    //    //        }
    //    //        color[ind] = "black";

    //    //    }


    //    //}

    //}
}




