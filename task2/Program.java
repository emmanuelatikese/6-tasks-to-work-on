import java.util.Scanner;
public class Program{
    public static void main(String[] args){
        System.out.print("Enter number to build triangular pattern: ");
        Scanner scanner = new Scanner(System.in);
        int num = Integer.parseInt(scanner.next());
        System.out.println("");
        for (int i = 1; i <= num; i++){
            for (int j = 1; j < i + 1; j++ ){
                System.out.print(j);
                System.out.print(" ");
            }
            System.out.println("");
        }
    }
}