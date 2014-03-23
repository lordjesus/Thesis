﻿using UnityEngine;
using System.Collections;
using SharpNeat.Phenomes;
using SharpNeat.Core;

public class PhotoTaxisEvaluator : MonoBehaviour, IPhenomeEvaluator<IBlackBox>
{

    const double StopFitness = 10.0;
    ulong _evalCount;
    bool _stopConditionSatisfied;
    StartEvaluation se;

    void Start()
    {
        se = GameObject.Find("Evaluator").GetComponent<StartEvaluation>();
    }

    public ulong EvaluationCount
    {
        get { return _evalCount; }
    }

    public bool StopConditionSatisfied
    {
        get { return _stopConditionSatisfied; }
    }

    public FitnessInfo Evaluate(IBlackBox box)
    {

        se.Evaluate(box);
        //yield return new WaitForSeconds(10);
        return FitnessInfo.Zero; 
    }
    /*
    public FitnessInfo Evaluate(IBlackBox box)
    {
        double fitness = 0;
        double output;
        double pass = 1.0;
        ISignalArray inputArr = box.InputSignalArray;
        ISignalArray outputArr = box.OutputSignalArray;

        _evalCount++;

        //----- Test 0,0
        box.ResetState();

        // Set the input values
        inputArr[0] = 0.0;
        inputArr[1] = 0.0;

        // Activate the black box.
        box.Activate();
        if (!box.IsStateValid)
        {   // Any black box that gets itself into an invalid state is unlikely to be
            // any good, so lets just bail out here.
            return FitnessInfo.Zero;
        }

        // Read output signal.
        output = outputArr[0];
        //  Debug.Assert(output >= 0.0, "Unexpected negative output.");

        // Calculate this test case's contribution to the overall fitness score.
        //fitness += 1.0 - output; // Use this line to punish absolute error instead of squared error.
        fitness += 1.0 - (output * output);
        if (output > 0.5)
        {
            pass = 0.0;
        }

        //----- Test 1,1
        // Reset any black box state from the previous test case.
        box.ResetState();

        // Set the input values
        inputArr[0] = 1.0;
        inputArr[1] = 1.0;

        // Activate the black box.
        box.Activate();
        if (!box.IsStateValid)
        {   // Any black box that gets itself into an invalid state is unlikely to be
            // any good, so lets just bail out here.
            return FitnessInfo.Zero;
        }

        // Read output signal.
        output = outputArr[0];
        //  Debug.Assert(output >= 0.0, "Unexpected negative output.");

        // Calculate this test case's contribution to the overall fitness score.
        //fitness += 1.0 - output; // Use this line to punish absolute error instead of squared error.
        fitness += 1.0 - (output * output);
        if (output > 0.5)
        {
            pass = 0.0;
        }

        //----- Test 0,1
        // Reset any black box state from the previous test case.
        box.ResetState();

        // Set the input values
        inputArr[0] = 0.0;
        inputArr[1] = 1.0;

        // Activate the black box.
        box.Activate();
        if (!box.IsStateValid)
        {   // Any black box that gets itself into an invalid state is unlikely to be
            // any good, so lets just bail out here.
            return FitnessInfo.Zero;
        }

        // Read output signal.
        output = outputArr[0];
        //  Debug.Assert(output >= 0.0, "Unexpected negative output.");

        // Calculate this test case's contribution to the overall fitness score.
        // fitness += output; // Use this line to punish absolute error instead of squared error.
        fitness += 1.0 - ((1.0 - output) * (1.0 - output));
        if (output <= 0.5)
        {
            pass = 0.0;
        }

        //----- Test 1,0
        // Reset any black box state from the previous test case.
        box.ResetState();

        // Set the input values
        inputArr[0] = 1.0;
        inputArr[1] = 0.0;

        // Activate the black box.
        box.Activate();
        if (!box.IsStateValid)
        {   // Any black box that gets itself into an invalid state is unlikely to be
            // any good, so lets just bail out here.
            return FitnessInfo.Zero;
        }

        // Read output signal.
        output = outputArr[0];
        //   Debug.Assert(output >= 0.0, "Unexpected negative output.");

        // Calculate this test case's contribution to the overall fitness score.
        // fitness += output; // Use this line to punish absolute error instead of squared error.
        fitness += 1.0 - ((1.0 - output) * (1.0 - output));
        if (output <= 0.5)
        {
            pass = 0.0;
        }

        // If all four outputs were correct, that is, all four were on the correct side of the
        // threshold level - then we add 10 to the fitness.
        fitness += pass * 10.0;

        if (fitness >= StopFitness)
        {
            _stopConditionSatisfied = true;
        }

        return new FitnessInfo(fitness, fitness);
    }
    */
    public void Reset()
    {
    }
}