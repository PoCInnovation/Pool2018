from Dataset import *
import math

def computeDistance(ex1, ex2):
    distance = 0.
    for i in range(0, len(ex1.inputs)):
        distance += math.pow(ex2.inputs[i] - ex1.inputs[i], 2)
    return math.sqrt(distance)

if __name__ == "__main__":  # just checking
     ex1 = Exemple()
     inputs = [1.0, 2.0]
     ex1.inputs.extend(inputs)
     
     ex2 = Exemple()
     inputs = [2.0, 1.0]
     ex2.inputs.extend(inputs)

     print(computeDistance(ex1, ex2))
