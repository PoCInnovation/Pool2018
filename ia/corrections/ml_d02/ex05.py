import operator

def getMostPresentCategory(neighbors):
    categories = {}
    for i in range(len(neighbors)):
        categorie = neighbors[i].outputs[0]
        if categorie in categories:
            categories[categorie] += 1
        else:
            categories[categorie] = 1
    sortedCategories = sorted(categories.items(), key=operator.itemgetter(1), reverse=True)
    return sortedCategories[0][0]
