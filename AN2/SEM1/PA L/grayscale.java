package grayscale;
import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.FileInputStream;
import java.io.FileOutputStream;

public class grayscale{
    public static void main(String[] args) {
        try {
            BufferedInputStream in = new BufferedInputStream(new FileInputStream("C:\\Users\\Admin\\Desktop\\image.bmp"));
            BufferedOutputStream out = new BufferedOutputStream(new FileOutputStream("C:\\Users\\Admin\\Desktop\\grayimage.bmp"));

            byte[] header = new byte[54];
            in.read(header);
            out.write(header);

            int width = ((header[21] & 0xff) << 24) | ((header[20] & 0xff) << 16) | ((header[19] & 0xff) << 8) | (header[18] & 0xff);
            int height = ((header[25] & 0xff) << 24) | ((header[24] & 0xff) << 16) | ((header[23] & 0xff) << 8) | (header[22] & 0xff);
            int padding = (4 - (width * 3) % 4) % 4;

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    int blue = in.read();
                    int green = in.read();
                    int red = in.read();

                    int gray = (int)(0.299 * red + 0.587 * green + 0.114 * blue);
                    gray = Math.min(255, Math.max(0, gray));

                    out.write(gray);
                    out.write(gray);
                    out.write(gray);
                }
                for (int p = 0; p < padding; p++) {
                    in.read();
                    out.write(0);
                }
            }

            in.close();
            out.close();
        } catch (Exception e) {
            e.printStackTrace();
}