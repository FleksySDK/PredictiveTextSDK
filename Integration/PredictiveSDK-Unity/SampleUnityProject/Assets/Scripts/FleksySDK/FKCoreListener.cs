// ****************************************************************************
// (c) 2023 Thingthing LTD
// ****************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface FKCoreListener
{
    public void OnCurrentWordPredictions(ArrayList predictions);

    public void OnNextWordPredictions(ArrayList predictions);

    public void OnSwipeWordPredictions(ArrayList predictions);


}
