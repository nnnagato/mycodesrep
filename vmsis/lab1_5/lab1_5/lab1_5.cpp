#include <iostream>
#include <string>

using namespace std;

int converter(string nineteenDecimal)
{
	
	int decimal = 0;
	int base = 1;
	char alphabet[9] = {'a','b','c','d','e','f','g','h','j'};
	for (int i = nineteenDecimal.size(); i >= 0; i--)
	{
		try
		{
			decimal += (int)nineteenDecimal[i] * base;
		}
		catch (...)
		{
			if (find(alphabet, alphabet + 9, nineteenDecimal[i]) != alphabet + 8)
			{
				decimal += (distance(alphabet, find(alphabet, alphabet + 9, nineteenDecimal[i])) + 10) * base;
			}
			else
			{
				cout << "Укажите число в девятнадцатиричном формате с маленькими буквами" << endl;
				break;
			}
		}
		
		base *= 19;
		
		
	}

	cout << "The decimal equivalent is: " << converter(nineteenDecimal) << endl;
	return 0;

	/*for (int i = nineteenDecimal.size() - 1; i >= 0; i--) {
		decimal += (nineteenDecimal[i] - '0') * base;
		base *= 19;
	}
	return decimal;
	*/
}


int main() {
	string nineteenDecimal;
	
	while(true)
	{
		cout << "Enter a number in nineteen-decimal number system: ";
		cin >> nineteenDecimal;
		converter(nineteenDecimal);
		/*cout << "The decimal equivalent is: " << converter(nineteenDecimal) << endl;*/
	}
	return 0;
}