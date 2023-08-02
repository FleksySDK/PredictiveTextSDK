using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FKPredictionItem 
{
    public string label = "";
    public string type = "";
    public double  score = 0.0;


    public FKPredictionItem(string label)
    {
        this.label = label;
     
    }

    public FKPredictionItem(string label, string type, double score) {
        this.label = label;
        this.type = type;
        this.score = score;
    }

}
