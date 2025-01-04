import java.util.Scanner;

public class TempConverter{

    public static Double ConvertToCelsius(Double fahrent){
        return (5* (fahrent - 32) /9);
    }

    public static Double ConvertToFahrenheit(Double celsius){
        return(1.8*celsius + 32);
    }

    public static void main(String[] args){
        System.out.println("Your temperature Convertor");

        Boolean x = true;
        while (x) {
            System.out.println("--------------------------------");
            System.out.print("1.Convert to Celsius \n2.Convert to Fahrenheit\n3.Exit\n");
            System.out.print("Enter option:");
            Scanner scan = new Scanner(System.in);
            String res = scan.next();
            System.out.println("\n");
            try {
                Integer userRes = Integer.parseInt(res);

                try {
                    switch (userRes) {
                        case 1:
                            System.out.println("Celsius Convertor");
                            System.out.println("--------------------------------");
                            System.out.print("Fahrenheit Value:");
                            Scanner fahScanner = new Scanner(System.in);
                            String fahres = fahScanner.next();
                            System.out.println("\n");
                            Double valFah = Double.parseDouble(fahres);
                            System.out.println("To Celsius value: " + ConvertToCelsius(valFah));
                            break;

                        case 2:

                            System.out.println("--------------------------------");
                            System.out.println("Fahrenheit Convertor");
                            System.out.print("Celsius Value:");
                            Scanner celScanner = new Scanner(System.in);
                            String resCel = celScanner.next();
                            System.out.println("\n");
                            Double valCel = Double.parseDouble(resCel);
                            System.out.println("To Fahrenheit value: " + ConvertToFahrenheit(valCel));
                            break;
                        case 3:
                            x = false;
                            System.out.println("Bye...");
                            break;
                    }
                } catch (Exception e) {
                    System.out.println("Enter the value in either number or decimal form");
                }

            } catch (Exception e) {
                System.out.println("Enter from (1-3) to select one of these options");
            }
        }

    }
}