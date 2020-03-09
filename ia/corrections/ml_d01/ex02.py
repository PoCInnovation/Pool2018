import numpy as np
import matplotlib.pyplot as plt

x = np.linspace(-10, 10, 30)
y = 3 * x + 4
plt.xlim(-10, 10)
plt.plot(x, y)
plt.show()
